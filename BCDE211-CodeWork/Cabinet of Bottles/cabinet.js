var Cabinet = /** @class */ (function () {
    function Cabinet() {
        this.allMyBottles = [];
        this.bottleCount = 0;
    }
    Cabinet.prototype.addBottle = function (bottleName, bottleType, bottleFlavour, bottleAge) {
        var aNewBottle = new Bottle(bottleName, bottleType, bottleFlavour, bottleAge);
        if (!aNewBottle) {
            return;
        }
        else {
            this.allMyBottles.push(aNewBottle);
            this.bottleCount += 1;
        }
    };
    Cabinet.prototype.getCount = function () {
        return this.bottleCount;
    };
    Cabinet.prototype.getAllMyBottles = function () {
        var returnstring = "";
        for (var _i = 0, _a = this.allMyBottles; _i < _a.length; _i++) {
            var Bottle = _a[_i];
            returnstring += 'The Bottle ' + Bottle.name + ' is a ' + Bottle.type + ' spirits and has a flavour of ' + Bottle.flavour + ' and is aged for a minimum time of ' + Bottle.age + ' years <br><br>';
        }
        return returnstring;
    };
    return Cabinet;
}());
