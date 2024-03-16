package com.sample;


public class UserData {

  private String name;
  private String surname;
  private long age;
  private String login;
  private String password;
  private String email;
  private java.sql.Timestamp registrationDate;
  private long userId;


  public String getName() {
    return name;
  }

  public void setName(String name) {
    this.name = name;
  }


  public String getSurname() {
    return surname;
  }

  public void setSurname(String surname) {
    this.surname = surname;
  }


  public long getAge() {
    return age;
  }

  public void setAge(long age) {
    this.age = age;
  }


  public String getLogin() {
    return login;
  }

  public void setLogin(String login) {
    this.login = login;
  }


  public String getPassword() {
    return password;
  }

  public void setPassword(String password) {
    this.password = password;
  }


  public String getEmail() {
    return email;
  }

  public void setEmail(String email) {
    this.email = email;
  }


  public java.sql.Timestamp getRegistrationDate() {
    return registrationDate;
  }

  public void setRegistrationDate(java.sql.Timestamp registrationDate) {
    this.registrationDate = registrationDate;
  }


  public long getUserId() {
    return userId;
  }

  public void setUserId(long userId) {
    this.userId = userId;
  }

}
