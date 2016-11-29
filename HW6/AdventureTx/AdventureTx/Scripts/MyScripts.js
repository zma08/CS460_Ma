$(document).ready(function () {
    $(".zma").click( function ()
    {
        //alert("hi");
        //document.getElementById('reviews').innerHTML = 'Hello zhen dong';
        
        $.ajax({
            type: 'GET',
            url: '/Home/CheckReview/',
            data: {pId: $('#pId').val()},
            dataType: 'json',
            success: function (Data) {
                console.log('success:', Data);
                var tblStr ="";
                var trStr = "";
                if (Data.isReviewed) {
                    $.each(Data.productReviews, function (i, item) {

                        trStr += '<tr><td>' + item.Rating + '</td><td>' + item.Review + '</td><td>' + new Date(parseInt(item.ReviewDate.substr(6))) + '</td><td>' + item.ReviewerName + '</td>';
                    });
                    tblStr = '<table class="table "><th>Rating</th><th>common</th><th>Review Date</th><th>Reviewer name</th>' + trStr + '</table>'                   
                    $('#reviews').html(tblStr);
                }
                else {
                    $('#reviews').html(Data.message);
                    document.getElementById('reviews').style.color = "Red";
                }
               
            },
            error: function(){alert("error loading")}
        });
        return false;
    });
});