let priceValueElements = 
    [
        document.getElementById("BuildingArea"),
        document.getElementById("PitDepth"),
        document.getElementById("WinterCoefficient"),
        document.getElementById("Inteco"),
        document.getElementById("PlotArea"),
    ];

priceValueElements.forEach(function (priceValueElement) {
    priceValueElement.onkeydown = function () {
        prohibitTextInput(this);
    };
    
    priceValueElement.onkeyup = function () {
        prohibitTextInput(this);
    };
});

function prohibitTextInput(element){
    element.value = element.value.replace(/[^0-9\,]/g, '');
}