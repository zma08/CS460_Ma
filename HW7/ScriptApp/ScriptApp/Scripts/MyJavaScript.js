$(document).ready(function() {

    $('#browse').on('click',function (e) {
        e.preventDefault();
        e.stopImmediatePropagation();
        $area = $('#show');
      
            $.ajax({
                type: 'GET',
                url: '/Quote/History',//mapped url by a more meaningful understandable url, it will return the same with Stock/Browse
                //dataType: 'text',
                data : { name : $('#ticker').val()},//json format------name and value pairs
                
                success: function (newData) {
                    
                    var tr = "";
                    var str = "";
                    $.each(newData, function(i, item) {
                        {
                            tr += "<tr><td>" + item.Date.toString() + "</td><td>" + item.Open.toFixed(2) + "</td><td>"+ item.High.toFixed(2) + "</td><td>" + item.Low.toFixed(2) + "</td><td>" + item.Volume + "</td><td>" + item.Close.toFixed(2) + "</td><td>" + item.AdjClose.toFixed(2) + "</td></tr>";
                        }
                    
                    });
                    str =
                      "<table class='table table-bordered>td table-striped table-hover'><th>Date</th><th>Open</th><th>High</th><th>Low</th><th>Volume</th><th>Close</th><th>Adj Close</th>" +tr+"</table>";
                    $area.html(str);
                    console.log('success', newData[0]);
                },

                error: function () {
                    alert("error when loading");//if talking to server with any issues, then will alert with a message error loading
                }
            });
        return false;

    });

    $('#research').on('click', function(e) {
        $area = $('#show');

        e.preventDefault();
        e.stopImmediatePropagation();
            $.ajax({
                type: 'GET',
                url: '/Stock/Browse',
                data: { 'Name': $('#ticker').val() },
                dataType: 'json',
                success: function(newData) {
                   console.log('success', newData);
                   $area.html(JSON.stringify(newData));
                   var g = new Dygraph($area,newData,
                   {
                       customBars: true,
                       logscale: true
                   });

                },
            error: function(newData1) {
                alert("error when loading...");
            }
       
    });

        return false;
    });
});

