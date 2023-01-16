import { reactive } from "vue";

class Userinfo {
  public username: string;
  public usertype: number;

  public id: number;
  public name: string;
  public surname: string;
  public city: string;
  public addres: string;
  public post_code: number;
  public password: string;
  public score: number;


  public constructor() {
    if(localStorage.getItem('username') != null)
    {
      this.username = localStorage.getItem('username');
      this.usertype = localStorage.getItem('usertype');
      this.id = localStorage.getItem('id');
      this.name = localStorage.getItem('name');
      this.surname = localStorage.getItem('surname');
      this.city = localStorage.getItem('city');
      this.addres = localStorage.getItem('addres');
      this.post_code = localStorage.getItem('post_code');
      this.password = localStorage.getItem('password');
      this.score = localStorage.getItem('score');
    }
    else{
      this.username = "";
      this.usertype = 0;
      this.id = 0;
      this.name = "";
      this.surname = "";
      this.city = "";
      this.addres = "";
      this.post_code = 0;
      this.password = "";
      this.score = 0;
    }

  }
}

export const store = reactive({
  userinfo: new Userinfo(),
  setUser(type: number, username: string, 
    id: number, name: string, surname: string, city: string, addres: string, post_code: number, password: string, score: number) {

    this.userinfo.username = username;
    this.userinfo.usertype = type;

    this.userinfo.id = id;
    this.userinfo.name = name;
    this.userinfo.surname = surname;
    this.userinfo.city = city;
    this.userinfo.addres = addres;
    this.userinfo.post_code = post_code;
    this.userinfo.password = password;
    this.userinfo.score = score;

  },
});
