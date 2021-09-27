(function () {
    'use strict';

    angular
        .module('ChatApp')
        .service('ChatApiService', ChatApiService);

    ChatApiService.$inject = ['$http'];

    function ChatApiService($http) {

        var baseUrl = 'api/chat';

        var services = {
            getMessages: getMessages,
            addMessage: addMessage
        };

        function getMessages() {
            return $http.get(baseUrl);
        }

        function addMessage(user, message) {
            return $http.post(baseUrl,
                JSON.stringify({ user: user, message: message }),
                { headers: { 'Content-Type': 'application/json' } });
        }

        return services;
    };
})();