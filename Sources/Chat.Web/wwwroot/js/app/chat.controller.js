(function () {
    'use strict';

    angular
        .module('ChatApp')
        .controller('ChatController', ChatController);

    ChatController.$inject = ['ChatSignalrService', 'ChatApiService', '$scope'];

    function ChatController(chatSignalrService, chatApiService, $scope) {
        var vm = this;

        vm.$onInit = init;

        vm.user = 'User 1';
        vm.message = 'message 1';
        vm.messages = [];

        vm.send = sendMessage;

        function init() {
            chatApiService
                .getMessages()
                .then((dto) => initMessageList(dto.data))
                .then(initSignalrService);
        }

        function initMessageList(chatDto) {
            var messages = chatDto.messages;

            angular.forEach(messages, addMessageToList);
        }

        function addMessageToList(messageItem) {
            vm.messages.push({ user: messageItem.user, message: messageItem.message });
        }

        function initSignalrService() {
            chatSignalrService.startConnection();
            chatSignalrService.onMessageReceived(handleMessageReceived);
        }

        function sendMessage() {
            chatApiService.addMessage(vm.user, vm.message).then(dto => chatSignalrService.sendMessage(dto.data.user, dto.data.message));
        }

        function handleMessageReceived(user, message) {
            vm.messages.push({ user: user, message: message });
            $scope.$apply();
        }
    };
})();