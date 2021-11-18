//todo надо сделать один файл запрета. Не забыть!!!!

let priceValueElements =
    [
        document.getElementById("Nds"),
        document.getElementById("BudgetCoefficient"),
        document.getElementById("InflationRate"),
        document.getElementById("IntecoCoefficient"),
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