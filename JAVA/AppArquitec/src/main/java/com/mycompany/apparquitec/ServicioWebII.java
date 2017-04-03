/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.mycompany.apparquitec;

import com.arquitectura.models.Peticion;
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
@WebServlet(name = "ServicioWebII", urlPatterns = {"/ServicioWebII"})
public class ServicioWebII extends HttpServlet {

    protected void procces(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        PrintWriter out = response.getWriter();
        Peticion p = new Peticion();
        p.setName(request.getParameter("name"));
        p.setLastName(request.getParameter("lastName"));
        p.setEmail(request.getParameter("email"));
        p.setPhoneNumber(request.getParameter("phoneNumber"));
        p.setId(request.getParameter("id"));
        p.setNumb1(Integer.parseInt(request.getParameter("p1")));
        p.setNumb2(Integer.parseInt(request.getParameter("p2")));
      

        out.println("<html>");
        out.println("<head>");
        out.println("<title>Resultado</title>");
        out.println("</head>");
        out.println("<body bgcolor=\"white\">");
        out.println("<h1>");
         out.write("Suma :");
        out.write("<br>");
        out.write("p1");
        out.write(" ( " + p.getNumb1() + " )");
        out.write(" + ");
        out.write("p2");
        out.write(" ( " + p.getNumb2() + " )");
        out.write(" = ");
        out.write((p.getNumb1() + p.getNumb2()) + "");
        out.println("</h1>");
        
        out.write("<h2>Datos de la persona: ");
         out.write("<br>");
        out.write("Nombre: " + p.getName());
         out.write("<br>");
        out.write("Apellido: " + p.getLastName());
         out.write("<br>");
        out.write("Id: "+ p.getId());
         out.write("<br>");
        out.write("Email: " + p.getEmail());
         out.write("<br>");
        out.write("Numero de telefono: "+ p.getPhoneNumber());
        out.write("<br>");
        out.write("</h2>");
        out.println("</body>");
        out.println("</html>");

   
      
        out.close();
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        procces(request, response);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        procces(request, response);
    }

}
