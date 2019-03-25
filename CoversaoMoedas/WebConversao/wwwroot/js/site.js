$("button").click(function () {

    // set endpoint and your access key
    endpoint = 'live'
    access_key = 'YOUR_ACCESS_KEY';

    // get the most recent exchange rates via the "live" endpoint:
    $.ajax({
        url: 'http://apilayer.net/api/' + endpoint + '?access_key=' + access_key,
        dataType: 'jsonp',
        success: function (json) {
            
            alert(json.quotes.USDGBP);
        }
    });
});
