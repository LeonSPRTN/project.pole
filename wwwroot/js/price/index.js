let priceValueElement = document.getElementById("PriceValue");

priceValueElement.onkeydown = function(){
    prohibitTextInput(this);
}
priceValueElement.onkeyup = function(){
    prohibitTextInput(this);
}

function prohibitTextInput(element){
    element.value = element.value.replace(/[^0-9\,]/g, '');
}