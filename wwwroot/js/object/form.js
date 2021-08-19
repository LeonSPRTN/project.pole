$(function () {
    var $region = $('[name="Region"]'),
        $district = $('[name="District"]'),
        $city = $('[name="City"]'),
        $street = $('[name="Street"]'),
        $building = $('[name="Building"]');

    var $tooltip = $('.tooltip');

    $.fias.setDefault({
        parentInput: '.js-form-address',
        verify: true,
        select: function (obj) {
            setLabel($(this), obj.type);
            $tooltip.hide();
        },
        check: function (obj) {
            var $input = $(this);

            if (obj) {
                setLabel($input, obj.type);
                $tooltip.hide();
            }
            else {
                showError($input, 'Введено неверно');
            }
        },
        checkBefore: function () {
            var $input = $(this);

            if (!$.trim($input.val())) {
                $tooltip.hide();
                return false;
            }
        },
        change: function (obj) {
            if(obj && obj.parents){
                $.fias.setValues(obj.parents, '.js-form-address');
            }
        },
    });

    $region.fias('type', $.fias.type.region);
    $district.fias('type', $.fias.type.district);
    $city.fias('type', $.fias.type.city);
    $street.fias('type', $.fias.type.street);
    $building.fias('type', $.fias.type.building);

    $district.fias('withParents', true);
    $city.fias('withParents', true);
    $street.fias('withParents', true);


    // Отключаем проверку введённых данных для строений
    $building.fias('verify', false);

    //TODO немного странная работа. Для хранения в базе не хорошо. Что нибудь надо придумать
    // function setLabel($input, text) {
    //     text = text.charAt(0).toUpperCase() + text.substr(1).toLowerCase();
    //     $input.parent().find('label').text(text);
    // }

    function showError($input, message) {
        $tooltip.find('span').text(message);

        var inputOffset = $input.offset(),
            inputWidth = $input.outerWidth(),
            inputHeight = $input.outerHeight();

        var tooltipHeight = $tooltip.outerHeight();

        $tooltip.css({
            left: (inputOffset.left + inputWidth + 10) + 'px',
            top: (inputOffset.top + (inputHeight - tooltipHeight) / 2 - 1) + 'px'
        });

        $tooltip.show();
    }
});

$(document).ready(function (){
    $('#btn-enable').click(function (){
        $('input').removeAttr('disabled');
        $('#btn-submit').removeAttr('style');
    });

    $('#btn-cancel').click(function (){
        $('input').attr('disabled', 'disabled');
        $('#btn-submit').attr('style', 'display: none');
    });
});