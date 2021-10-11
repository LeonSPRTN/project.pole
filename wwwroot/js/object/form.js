// Замените на свой API-ключ
var token = "ad3bbfe0bf9ad96ff2cc9fb31ecd13ba439c7b71";

var type = "ADDRESS";
var $region = $("#region");
var $area = $("#area");
var $city = $("#city");
var $settlement = $("#settlement");
var $street = $("#street");
var $house = $("#house");

function showPostalCode(suggestion) {
    $("#postal_code").val(suggestion.data.postal_code);
}

function clearPostalCode() {
    $("#postal_code").val("");
}

// регион
$region.suggestions({
    token: token,
    type: type,
    hint: false,
    bounds: "region"
});

// район
$area.suggestions({
    token: token,
    type: type,
    hint: false,
    bounds: "area",
    constraints: $region
});

// город и населенный пункт
$city.suggestions({
    token: token,
    type: type,
    hint: false,
    bounds: "city",
    constraints: $area,
    onSelect: showPostalCode,
    onSelectNothing: clearPostalCode
});

// geolocateCity($city);

// город и населенный пункт
$settlement.suggestions({
    token: token,
    type: type,
    hint: false,
    bounds: "settlement",
    constraints: $city,
    onSelect: showPostalCode,
    onSelectNothing: clearPostalCode
});

// улица
$street.suggestions({
    token: token,
    type: type,
    hint: false,
    bounds: "street",
    constraints: $settlement,
    onSelect: showPostalCode,
    onSelectNothing: clearPostalCode
});

// дом
$house.suggestions({
    token: token,
    type: type,
    hint: false,
    bounds: "house",
    constraints: $street,
    onSelect: showPostalCode,
    onSelectNothing: clearPostalCode
});
