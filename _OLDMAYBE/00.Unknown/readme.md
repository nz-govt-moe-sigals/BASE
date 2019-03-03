## About ##

You can use whatever ALM you want to you. 

In an enterprise, I'd suggest VSTS due to a) the completeness of the services within the ALM, and b) its rigourous permission based system, but totally understand if you want to use GitHub's pipeline, Jenkins, etc.



### Warning ###

**NO** Environment Passwords should be embedded in any file, script, etc. in this repository.

Tip: remember that you can use files with *.ignore or *.secret at the end to ensure that files are not committed by mistake.