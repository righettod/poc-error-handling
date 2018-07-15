<%@ page language="java" isErrorPage="true" contentType="application/json; charset=UTF-8" pageEncoding="UTF-8"%>
<%
String errorMessage = exception.getMessage();
//Log the exception via the content of the implicit variable named "exception"
//...
//We build a generic response with a JSON format because we are in a REST API app context
//We also add an HTTP response header to indicate to the client app that the response is an error
response.setHeader("X-ERROR", "true");
response.setStatus(200);
%>
{"message":"An error occur, please retry"}