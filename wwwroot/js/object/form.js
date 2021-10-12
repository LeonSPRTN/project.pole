// Замените на свой API-ключ
const token = "ad3bbfe0bf9ad96ff2cc9fb31ecd13ba439c7b71";

const type = "ADDRESS";
const $region = $("#region");
const $area = $("#area");
const $city = $("#city");
const $settlement = $("#settlement");
const $street = $("#street");
const $house = $("#house");

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
});

// geolocateCity($city);

// город и населенный пункт
$settlement.suggestions({
    token: token,
    type: type,
    hint: false,
    bounds: "settlement",
    constraints: $city,
});

// улица
$street.suggestions({
    token: token,
    type: type,
    hint: false,
    bounds: "street",
    constraints: $settlement,
});

// дом
$house.suggestions({
    token: token,
    type: type,
    hint: false,
    bounds: "house",
    constraints: $street,
});
