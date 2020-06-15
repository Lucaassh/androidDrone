package com.example.droneone.ui.bd;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class conecta {

    static Connection conexao = null;
    static Statement consulta;
    static ResultSet resultadoDaConsulta;
    static String nomeDaTabela = "";
    static String servidor = "3.128.7.77";
    static String banco = "database1";
    static String usuario = "admin";
    static String senha = "Alohomora01";
    static String url = "jdbc:mysql://" + servidor + "/" + banco;
    static String status;

    static void testeDaConexao() {
        try {
            conexao = DriverManager.getConnection(url, usuario, senha);
            status = "Conexao com o banco realizada com sucesso.";

        } catch (Exception e) {
            status = "Falha durante o teste de conexão!";
            e.printStackTrace();
        } finally {
            if (conexao != null) {
                try {
                    conexao.close();
                    System.out.println("Conexão com o banco encerrada com sucesso.");
                } catch (SQLException e) {
                    e.printStackTrace();
                    System.out.println("Falha no encerramento da conexão com o banco!");
                }
            }
        }
    }


}
