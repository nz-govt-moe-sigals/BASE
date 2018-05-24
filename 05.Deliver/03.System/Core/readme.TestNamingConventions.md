# About # 

A standard for the build pipeline

## Why ##

For all tests that are doing Http web requests to deployed instance should be named Ux.Tests 
This is regardless of whether they include Selenium or not. 

this is because the build pipeline will execute these tests at a different time and requires different build defintion to executing them.
Unit tests should be run mufch earlier in the build piplline, because if they fail then there is no point in running the rest. 

If they are only unit tests, then do not include Ux.Tests in the name