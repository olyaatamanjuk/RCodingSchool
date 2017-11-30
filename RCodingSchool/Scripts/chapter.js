$(document).ready(function () {
    var firstTopicId = $('.first-topic-id').val();
    var md = markdownit({ html: true }).use(texmath.use(katex));
    var modal = $('#delete-modal');
    var topicIdToDelete;
    $('.topic').on('click', function (event) {
        var topicId = event.target.getAttribute('topic-id');
        loadTopicDetailes(topicId);
    });
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

    $('.delete-topic').on('click', function (event) {
        event.preventDefault();

        topicIdToDelete = event.target.getAttribute('topic-id');

        modal.modal('show');
    });

    $('.btn-yes').on('click', function () {
        $.get(`/Chapter/RemoveTopic/${topicIdToDelete}`)
            .done(function () {
                modal.modal('hide');
                location.reload();
            });
    });

    $('.btn-no').on('click', function () {
        modal.modal('hide');
    });

    loadTopicDetailes(firstTopicId);
});