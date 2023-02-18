import { Component } from '@angular/core';
import { HttpService } from '../service/http.service';
import { Validation } from './type/validation';

const BASE_URL = 'http://localhost:52627/'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  creditCard: string = ''
  validationResult: Validation = { CardNumber: '', CardType: '', Validity: '' };

  constructor(
    private _httpService: HttpService,
  ) { }

  async ngOnInit() {
    //await this.checkValidation(this.creditCard);//'4408 0412 3456 7893'
  }

  private async checkValidation(creditCard: string) {
    const url: string = BASE_URL + 'api/validateCreditCard/' + creditCard;
    return await this._httpService
      .getData(url)
      .then((result) => {
        return result;
      })
      .catch((ex) => {
        console.error('error:', ex);
      });
  }

  public async validate() {
    this.validationResult = { CardNumber: '', CardType: '', Validity: '' }
    if (this.creditCard.length > 0) {
      this.validationResult = await this.checkValidation(this.creditCard);
    }
  }

  public isNumber(evt: any) {
    evt = evt ? evt : window.event;
    var charCode = evt.which ? evt.which : evt.keyCode;
    if (charCode != 32 && charCode > 31 && (charCode < 48 || charCode > 57)) {
      return false;
    }
    return true;
  }
}
