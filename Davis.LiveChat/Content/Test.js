var MyClass;
(function (MyClass) {
    var ClassName = /** @class */ (function () {
        function ClassName() {
        }
        ClassName.prototype.OutputText = function () {
            console.log("outputting text!");
        };
        return ClassName;
    }());
    MyClass.X = new ClassName();
})(MyClass || (MyClass = {}));
//# sourceMappingURL=Test.js.map