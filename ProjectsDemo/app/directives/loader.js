(function () {
    'use strict';

    angular
        .module('app')
        .directive('loader', Directive);

    function Directive() {
        return {
            restrict: 'E',
            template: 
"<div class=\"loader-overlay\">\
    <div class=\"loader\">\
        <div></div> <div></div> <div></div> <div></div>\
    </div>\
</div>"
        };
    }
})();