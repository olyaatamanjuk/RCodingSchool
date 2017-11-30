$(document).ready(function () {
    var firstTopicId = $('first-topic-id').val();
    var md = markdownit({ html: true }).use(texmath.use(katex));
    var modal = $('#myModal');
    function loadTopicDetailes(id) {
        var url = "/chapter/topic/";
        if (id)
            $.post(url, { id: id })
                .done(function (response) {
                    var htmlText = decodeURI(response);
                    var res = htmlText.replace("<img src", "img class=\"img-responsive\" src");
                    $("#currentTopic").html(md.render(decodeURI(response)));
                });
    }

    $('delete-topic').on('click', function (event) {
        event.preventDefault();

        var topicId = event.target.topicId;
        $('')
    })

    loadTopicDetailes(firstTopicId);
});