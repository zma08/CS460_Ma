$(document).ready(function() {
    
    $('#browse').on('click',function (e) {
       
        $area = $('#show');
        var name = $('#ticker').val();
        console.log(name);
            $.ajax({
                type: 'GET',
                url: '/Quote/History',//mapped url by a more meaningful understandable url, it will return the same with Stock/Browse
                data: {name: name},
                dataType: 'json',
               //json format------name and value pairs
                
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
                    console.log('success', newData);
                },

                error: function () {
                    alert("error when loading");//if talking to server with any issues, then will alert with a message error loading
                }
            });
        return false;

    });

    $('#research').on('click', function(e) {
       // $area = $('#show');
        var name = $('#ticker').val();
        e.preventDefault();
       
            $.ajax({
                type: 'GET',
                url: '/Quote/History/',
                data: { name: name },
                dataType:'json',
                success: function(Data) {
                   // console.log('success', JSON.stringify(Data));
                    console.log("length array", Data.length);
                 
                   
                    g = new Dygraph(document.getElementById('show'),Data,
                        {
                            
                            
                            axes:{
                                 x: {
                                        valueFormatter: Dygraph.dateString_,
                                        axisLabelFormatter: Dygraph.dateAxisFormatter,
                                        ticker: Dygraph.dateTicker
                                    }
                                }
                        },
                     
                    {
                        // options go here. See http://dygraphs.com/options.html
                        legend: 'always',
                        animatedZooms: true,
                        title: 'dygraphs chart template'
                    });

                },
                
            error: function(newData1) {
                alert("error when loading...");
            }
       
    });

        return false;
    });
});

