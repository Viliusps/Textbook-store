import { reactive } from "vue";



class CurrentMessage {

  public id: number;
  public message: string;
  public type: string;
  public fk_user: number;

  public constructor() {

    this.id = 0;
    this.message = "";
    this.type = "";
    this.fk_user = 0;
  }
}

export const storeMessage = reactive({
  currentmessage: new CurrentMessage(),
  setMessage(id: number, message: string, type: string, fk_user: number) {

    this.currentmessage.id = id;
    this.currentmessage.message = message;
    this.currentmessage.type = type;
    this.currentmessage.fk_user = fk_user;

  },
});
