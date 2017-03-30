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
@WebServlet(name = "ServicioWebII", urlPatterns = {"/ServicioWebII"})
public class ServicioWebII extends HttpServlet {

    protected void isAlive(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        PrintWriter out = response.getWriter();

        String p1 = "p1";
        String p2 = "p2";
        String value1 = request.getParameter(p1);
        String value2 = request.getParameter(p2);
        int n1 = Integer.parseInt(value1);
        int n2 = Integer.parseInt(value2);

        out.println("<html>");
        out.println("<head>");
        out.println("<title>Resultado</title>");
        out.println("</head>");
        out.println("<body bgcolor=\"white\">");
        out.println("<h1>");
         out.write("Aqui el resultado:");
        out.write("<br>");
        out.write(p1);
        out.write(" ( " + n1 + " )");
        out.write(" + ");
        out.write(p2);
        out.write(" ( " + n2 + " )");
        out.write(" = ");
        out.write((n1 + n2) + "");
        out.println("</h1>");
        out.println("</body>");
        out.println("</html>");

   
      
        out.close();
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
