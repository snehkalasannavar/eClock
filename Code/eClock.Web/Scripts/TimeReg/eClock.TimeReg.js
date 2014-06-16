$(function () {
    var startDate;
    var endDate;

    var selectCurrentWeek = function () {
        window.setTimeout(function () {
            $('.week-selector').find('.ui-datepicker-current-day a').addClass('ui-state-active')
        }, 1);
    }

    $('.week-selector').datepicker({
        showOtherMonths: true,
        selectOtherMonths: true,
        onSelect: function (dateText, inst) {
            var date = $(this).datepicker('getDate');
            startDate = new Date(date.getFullYear(), date.getMonth(), date.getDate() - date.getDay());
            endDate = new Date(date.getFullYear(), date.getMonth(), date.getDate() - date.getDay() + 6);
            var dateFormat = "d/M/y";
            var startDateTxt = $.datepicker.formatDate(dateFormat, startDate, inst.settings);
            var endDateTxt = $.datepicker.formatDate(dateFormat, endDate, inst.settings);
            $('.selected-week').val(startDateTxt + " to " + endDateTxt);

            selectCurrentWeek();
        },
        beforeShowDay: function (date) {
            var cssClass = '';
            if (date >= startDate && date <= endDate)
                cssClass = 'ui-datepicker-current-day';
            return [true, cssClass];
        },
        onChangeMonthYear: function (year, month, inst) {
            selectCurrentWeek();
        }
    });
});