(function () {
    'use strict';

    angular
        .module('ChatApp')
        .controller('ChatController', ChatController);

    ChatController.$inject = ['ChatSignalrService', '$scope'];

    function ChatController(chatSignalrService, $scope) {
        var vm = this;

        vm.$onInit = init;

        vm.user = 'User 1';
        vm.message = 'message 1';
        vm.messages = [];

        vm.send = sendMessage;

        function init() {
            chatSignalrService.startConnection();
            chatSignalrService.onMessageReceived(handleMessageReceived);
        }
        
        function sendMessage() {
            chatSignalrService.sendMessage(vm.user, vm.message);
        }

        function handleMessageReceived(user, message) {
            vm.messages.push({ user: user, message: message });
            $scope.$apply();
        }
    };
})();