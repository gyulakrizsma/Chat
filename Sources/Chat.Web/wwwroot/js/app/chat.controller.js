(function () {
    'use strict';

    angular
        .module('ChatApp')
        .controller('ChatController', ChatController);

    ChatController.$inject = ['ChatSignalrService', 'ChatApiService', '$scope'];

    function ChatController(chatSignalrService, chatApiService, $scope) {
        var vm = this;

        vm.$onInit = init;

        vm.user = '';
        vm.message = '';
        vm.messages = [];

        vm.hasUser = false;

        vm.sendMessage = sendMessage;
        vm.joinChat = joinChat;

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
            vm.message = '';
        }

        function joinChat() {
            vm.hasUser = true;
        }

        function handleMessageReceived(user, message) {
            vm.messages.push({ user: user, message: message });
            $scope.$apply();
        }
    };
})();