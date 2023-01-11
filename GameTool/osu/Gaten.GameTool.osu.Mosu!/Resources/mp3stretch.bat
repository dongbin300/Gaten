set src=%1
set dest=%2
set args=%3 %4 %5 %6

lame --silent --decode %src% - | soundstretch stdin stdout %args% | lame --silent -v - %dest%
