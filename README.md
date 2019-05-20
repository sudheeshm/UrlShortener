# UrlShortener

The solution consists of 2 components
  1. The Web App
  2.  The back end Rest API
  
  The WebApp is a very thin application developed in ASP.Net Core 2.1 which allows users to enter a long url. Upon Submitting, the Application returns the details of Short Url.
  
  The Web API is also developed in ASP.Net Core 2.1. A seperate API was developed as, ideally the Url shortening service can be consumed as a stand alone system. The API has 2 methods which are consumed by the WebApp to Create Short Urls from a long Url. The API documentation can be found at https://urlshortenerapi20190520015813.azurewebsites.net/swagger/index.html ( this swagger site can be used to test this API as well)
  
  Both, App and the API doesn't have any authentication mechanism implemented. 
  The API doesn't have a permanant storage mechanism. Currently, it stores all data in a list variable. Aproduction version must have a persistent storage.
  
  There is logging mechanism implemented in the API, though it is not very complete.
  
  ~ End ~
  
  
  
  
  
