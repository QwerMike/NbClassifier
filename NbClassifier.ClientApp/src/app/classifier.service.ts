import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

@Injectable()
export class ClassifierService {

  private classifierUrl = 'http://localhost:56537/api/classifier';
  private headers = new Headers({'Content-Type': 'application/json'});

  constructor(private http: Http) { }

  classifyReview(review: string): Promise<string> {
    return this.http
               .post(this.classifierUrl, 
                     JSON.stringify(review), 
                     {headers: this.headers})
               .toPromise()
               .then(response => response.json() as string)
               .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}