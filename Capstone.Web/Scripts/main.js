$(document).ready(function () {

    var uri = '/api/bracket';

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

});



