$(document).ready(function () {

    var uri = '/api/bracket';

    var minimalData = {
        teams: [
          ["Team 1", "Team 2"], /* first matchup */
          ["Team 3", "Team 4"]  /* second matchup */
        ],
        results: [
          [[1, 2], [3, 4]],       /* first round */
          [[4, 6], [2, 1]]        /* second round */
        ]
    }

    $("#bracket").on("click", function (e) {
        var id = $('#tourId').val();
        $.getJSON(uri + '/' + id)
        .done(function (data) {
            //var myData = JSON.parse(data);
            $(function () {
                $('.demo').bracket({
                    init: data
                })
            })
            var myData = JSON.parse(data);
            console.log(myData)
        })
        var resizeParameters = {
            teamWidth: 80,
            scoreWidth: 20,
            matchMargin: 10,
            roundMargin: 50,
            init: minimalData
        };

        function updateResizeDemo() {
            $('#resize .demo').bracket(resizeParameters);
        }

        $(updateResizeDemo)
    });

    /* Called whenever bracket is modified
 *
 * data:     changed bracket object in format given to init
 * userData: optional data given when bracket is created.
 */
    function saveFn(data, userData) {
        var json = jQuery.toJSON(data)
        $('#saveOutput').text('POST ' + userData + ' ' + json)
        /* You probably want to do something like this
        jQuery.ajax("rest/"+userData, {contentType: 'application/json',
                                      dataType: 'json',
                                      type: 'post',
                                      data: json})
        */
    }


});



