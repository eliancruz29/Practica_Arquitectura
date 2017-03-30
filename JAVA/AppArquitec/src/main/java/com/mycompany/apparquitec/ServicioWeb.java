/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.mycompany.apparquitec;

import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 *
 * @author tpolanco
 */
/*
    Este es el servicio uno que provee a quien lo consuma un status http que indica que esta vivo con un ok.
    Este webservlet puede ser de dos tipos get y post, ya que todos los metodos reciben esto parametros
    
    
*/
@WebServlet(name = "ServicioWeb", urlPatterns = {"/ServicioWeb"})
public class ServicioWeb extends HttpServlet {

       protected void isAlive(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
            response.setContentType("text/html;charset=UTF-8");
            response.setStatus(HttpServletResponse.SC_OK);
            
        
    }

    
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        isAlive(request, response);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        isAlive(request, response);
    }

  
}
