$(document).ready(function () {
    document.getElementById("Tesselation").addEventListener("click", showMe);
    document.getElementById("Surrealism").addEventListener("click", showMe); 
    document.getElementById("Portrait").addEventListener("click", showMe);
    document.getElementById("Renaissance").addEventListener("click", showMe);

    function showMe()
    {
        //$('#show').hide();
        $.ajax({
                    type:'GET',
                    url: 'Home/Art/',
                    data: {data:this.attributes["id"].value},
                    dataType:'json',
                    success: function (Data)
                    {
                        $('#show').show();
                        $('#show').addClass("jumbotron");

                        var str = '';
                        var tblstr;
                        $.each(Data, function (i, item) {
                            str += '<tr><td class= "text-center text-danger">' + item.ArtWork + '</td><td class= "text-center text-danger">' + item.Artist + '</td></tr>'
                        });
                        tblstr = '<table class="table-bordered:th"><tr><th class= "text-center text-danger">ArtWork</th><th class= "text-center text-danger">Artist</th></tr>' + str + '</table>';
                        $('#show').html(tblstr);
                    }            
              });
    }
});

//$(document).click(function () { $('#show').hide();});