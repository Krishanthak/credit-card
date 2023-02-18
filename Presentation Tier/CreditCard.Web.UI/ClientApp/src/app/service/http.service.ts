import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class HttpService {
  constructor(private _httpClient: HttpClient) { }

  public async getData(dataUrl: string): Promise<any> {
    try {
      const response = await this._httpClient.get(dataUrl).toPromise();
      return response;
    } catch (error) {
      return this.handleError(error);
    }
  }

  private handleError(error: any): Promise<any> {
    return Promise.reject(error.message || error);
  }
}
