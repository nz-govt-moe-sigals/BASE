# About # 

It is a natural limitation of Stakeholders to view project objectives from their own experience, and desires.


In the short term, there are the Project Delivery Manager's objectives of getting something out the door, contrasted with the Development Team's desire to have more time to investigate how to do something, and assess which one is the most appropriate. The development team's believe that everybody should understand code as fluently as they understand their native tongue  often contrast with the Support Development Team's desire of having as much insight as possible (ie code comments and documentation) into how the application was intended to be built. The development team probably believe that nothing will ever go wrong with their deliverables -- which is often not the experience of Customer Support Team. etc.

A project has multiple Stakeholders with competing desires that all have to be met.

To meet as many of these desires, there are some design objectives to keep in mind while developing:


* To be confidential (ie use HTTPS correctly), to authorise and authenticate operation use by end users (using RBAC on OIDC).
* To be modular, in order to keep Core separate from Modules.
* To be WebAPI based, in order to force the UI development to not be ASP.MVC based (ie, client based UI, rather than server based UI).
