$(document).ready(function () {
    var firstTopicId = $('.first-topic-id').val();
    var md = markdownit({ html: true }).use(texmath.use(katex));
    var modal = $('#delete-modal');
    var chapterModal = $('#chapter-delete-modal');
    var chapterModalEdit = $('#chapter-edit-modal');
    var topicIdToDelete;
    var chapterIdToDelete;
    var chapterIdToEdit;

    $('.topic').on('click', function (event) {
        var topicId = event.target.getAttribute('topic-id');
        loadTopicDetailes(topicId);
    });
    function loadTopicDetailes(id) {
        var url = "/chapter/topic/";
        if (id)
            $.post(url, { id: id })
                .done(function (response) {
                    var htmlText = decodeURI(response.text);
                    var html = `<div><h3>${response.name}</h3><div>${md.render(htmlText)}</div></div>`
                    html = html.replace("<img src", "<img class=\"img-responsive\" src");
                    $("#currentTopic").html(html);
                });
    }

    $('.delete-topic').on('click', function (event) {
        event.preventDefault();

        topicIdToDelete = event.target.getAttribute('topic-id');

        modal.modal('show');
    });

    $('.delete-chapter').on('click', function (event) {
        event.preventDefault();

        chapterIdToDelete = event.target.getAttribute('chapter-id');

        chapterModal.modal('show');
    });

    $('.edit-chapter').on('click', function (event) {
        event.preventDefault();

        chapterIdToEdit = event.target.getAttribute('chapter-id');

        chapterModalEdit.modal('show');
    });

    $('.btn-yes').on('click', function () {
        $.get(`/Chapter/RemoveTopic/${topicIdToDelete}`)
            .done(function () {
                modal.modal('hide');
                location.reload();
            });
    });

    $('.btn-yes-chapter').on('click', function () {
        $.get(`/Chapter/RemoveChapter/${chapterIdToDelete}`)
            .done(function () {
                chapterModal.modal('hide');
                location.reload();
            });
    });

    $('.btn-yes-chapter-edit').on('click', function () {
        chapterName = document.getElementById("new-chapter-name").value.toString();
        $.get('/Chapter/EditChapter/', { "id": chapterIdToEdit, "newName": chapterName })
            .done(function () {
                chapterModalEdit.modal('hide');
                location.reload();
            });
    });

    $('.btn-no').on('click', function () {
        modal.modal('hide');
        chapterModal.modal('hide');
    });

    function show(id) {
        document.getElementById(id).style.visibility = "visible";
    }

    loadTopicDetailes(firstTopicId);
});