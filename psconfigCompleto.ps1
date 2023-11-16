#original em https://blog.stefan-gossner.com/2015/08/20/why-i-prefer-psconfigui-exe-over-psconfig-exe/
PSConfig.exe -cmd upgrade -inplace b2b -wait -cmd applicationcontent -install -cmd installfeatures -cmd secureresources -cmd services -install
