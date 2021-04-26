import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'messageUserName'
})
export class MessageUserNamePipe implements PipeTransform {

  transform(message: any ): String {
    if (message.owner){
      return "You";
    }else{
      return message.ownerName;
    }
  }

}
