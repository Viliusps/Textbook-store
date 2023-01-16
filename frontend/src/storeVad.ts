import { reactive } from "vue";

class Vadinfo {

  public id_all: number;
  public id_user: number;

  public id_pop: number;
  public id_par: number;
  public id_uz: number;

  public name: string;
  public price: number;
  public state: string;
  public isbn: string;
  public publisher: string;
  public pages: number;
  public year: number;
  public language: string;
  public description: string;

  public constructor() {
    if(localStorage.getItem('name') != null){

      this.id_all = localStorage.getItem('id_all');
      this.id_user = localStorage.getItem('id_user');
      this.id_pop = localStorage.getItem('id_pop');
      this.id_par = localStorage.getItem('id_par');
      this.id_uz = localStorage.getItem('id_uz');

      this.name = localStorage.getItem('name');
      this.price = localStorage.getItem('price');
      this.state = localStorage.getItem('state');
      this.isbn = localStorage.getItem('isbn');
      this.publisher = localStorage.getItem('publisher');
      this.pages = localStorage.getItem('pages');
      this.year = localStorage.getItem('year');
      this.language = localStorage.getItem('language');
      this.description = localStorage.getItem('description');

    }else{
      this.id_all = 0;
      this.id_user = 0;
      this.id_pop = 0;
      this.id_par = 0;
      this.id_uz = 0;

      this.name = "";
      this.price = 0;
      this.state = "";
      this.isbn = "";
      this.publisher = "";
      this.pages = 0;
      this.year = 0;
      this.language = "";
      this.description = "";
    }
    
  }
}

export const storeVad = reactive({
  vadinfo: new Vadinfo(),
  setVad(id_all: number, id_user: number, id_pop: number, id_par: number, id_uz: number, name: string, price: number,
    state: string, isbn: string, publisher: string, pages: number, year: number, language: string, description: string) {

    this.vadinfo.id_all = id_all;
    this.vadinfo.id_user = id_user;
    this.vadinfo.id_pop = id_pop;
    this.vadinfo.id_par = id_par;
    this.vadinfo.id_uz = id_uz;

    this.vadinfo.name = name;
    this.vadinfo.price = price;
    this.vadinfo.state = state;
    this.vadinfo.isbn = isbn;
    this.vadinfo.publisher = publisher;

    this.vadinfo.pages = pages;
    this.vadinfo.year = year;
    this.vadinfo.language = language;
    this.vadinfo.description = description;

  },
});
