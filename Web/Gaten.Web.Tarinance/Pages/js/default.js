<script type="text/javascript">
    $(function(){
        $('li').on('click', function () {
            $('li').removeClass('active');
            $(this).toggleClass('active');
        });
    });
</script>