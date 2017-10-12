
    (function () {
        // Declare a proxy to reference the hub.
        var chat = $.connection.chatHub;
        // Create a function that the hub can call to broadcast messages.
        chat.client.broadcastMessage = function (name, message, stringTime) {
            // Html encode display name and message.
            var encodedName = $('<div />').text(name).html();
            var encodedMsg = $('<div />').text(message).html();
            var now = new Date();
            var encodeNow = $('<div />').text(now).html();
            // Add the message to the page.
            $('#discussion').append('  <div class="media">' +
                     '<div class="media-left">' +
                         '<img src="../../Content/images/default_user.png" class="media-object" style="width:40px">' +
                     '</div>' +
                     '<div class="media-body">'+
                         '<h4 class="media-heading">' + encodedName + '<small> ' + stringTime + '</small></h4>' +
                         '<p>' + encodedMsg +'</p>'+
                     '</div>'+
                 '</div>'+
             '</div><hr>');
        };
        // Start the connection.
        console.log("Starting connection");
        $.connection.hub.start().done(function () {
            $('#sendmessage').click(function () {
                // Call the Send method on the hub.
                var currentUserMail = '@Model.Email';
                chat.server.send( $('#message').val(),currentUserMail);
                // Clear text box and reset focus for next comment.
                $('#message').val('').focus();
            });
        });
    });