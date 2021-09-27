(function () {
    'use strict';

    angular
        .module('ChatApp')
        .service('ChatSignalrService', ChatSignalrService);

    function ChatSignalrService() {

        var connection;

        var services = {
            startConnection: startConnection,
            sendMessage: sendMessage,
            onMessageReceived: onMessageReceived
        };

        function startConnection() {
            connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
            connection.start();
        }

        function sendMessage(user, message) {
            return connection.invoke("SendMessageAsync", user, message);
        }

        function onMessageReceived(callback) {
            connection.on("ReceiveMessage",
                function (user, message) {
                    return callback(user, message);
                });
        }

        return services;
    };
})();