(function () {
    setInterval(
        function () {
            var date = new Date();
            var hours = date.getUTCHours();
            if (hours < 10) {
                hours = "0" + hours
            }

            var minutes = date.getUTCMinutes();
            if (minutes < 10) {
                minutes = "0" + minutes
            }

            var seconds = date.getSeconds();
            if (seconds < 10) {
                seconds = "0" + seconds
            }

            $('#clock').text(hours + ":" + minutes + ":" + seconds);
        },
        1000);
})();