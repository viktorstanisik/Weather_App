import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'customPipes'
})
export class CustomPipesPipe implements PipeTransform {

  transform(value: number, ...args: unknown[]): string {
      let dtt = new Date(value * 1000).toDateString();
      return dtt;
  }

}
