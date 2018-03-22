# REST and SOAP WS Lab

## Velib Gateway Web Service
The main idea of this lab is to develop and deploy an intermediary Web service (IWS) between the Velib WS and some WS clients.

A first and minimal release of your lab project must consist in :

- a local Intermediary Web Service (on your own PC) that exposes a WS-SOAP API to access to the Velib Web Service (see lectures of session 2)
- a console client that allows to access to the IWS and request for the list of velib stations for a given city and the number of the available Velib at a given station.

Choose your own interactive instructions for that and add a “help” one to display all details about them.
Test this client not only on your PC but also remotely

## Extensions 

The implemented extentions   :
 - Graphical User Interface for the client 
 - Replace all the accesses to WS (beetween Velib WS and IWS, between IWS and WS Clients) with asynchronous ones. Some indications can be find just below.
 - Add a cache in IWS, to reduce communications between Velib WS and IWS
