package eu.righettod;

import net.minidev.json.JSONObject;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.context.request.WebRequest;

/**
 * Global error handler in charge of returning a generic error in case of unexpected error situation.
 */
@ControllerAdvice
public class RestResponseEntityExceptionHandler {

    @ExceptionHandler(value = {Exception.class})
    public ResponseEntity<Object> handleGlobalError(RuntimeException exception, WebRequest request) {
        //Log the exception via the content of the parameter named "exception"
        //...
        //We build a generic response with a JSON format because we are in a Web API app context
        //We also add an HTTP response header to indicate to the client app that the response is an error
        HttpHeaders responseHeaders = new HttpHeaders();
        responseHeaders.setContentType(MediaType.APPLICATION_JSON);
        responseHeaders.set("X-ERROR", "true");
        JSONObject responseBody = new JSONObject();
        responseBody.put("message", "An error occur, please retry");
        ResponseEntity<JSONObject> response = new ResponseEntity<>(responseBody, responseHeaders, HttpStatus.OK);
        return (ResponseEntity) response;
    }
}
