import { Component, OnInit } from '@angular/core';
import { Time } from '@angular/common';
import { TrainsService } from './../api/services/trains.service'
import { TrainsRm } from '../api/models';
import { FormBuilder, FormGroup } from '@angular/forms';
import { SearchTrains$Plain$Params } from '../api/fn/trains/search-trains-plain'

@Component({
  selector: 'app-search-trains',
  templateUrl: './search-trains.component.html',
  styleUrls: ['./search-trains.component.css']
})
export class SearchTrainsComponent implements OnInit {

  searchResult: TrainsRm[] = []


  constructor(private trainsService: TrainsService,
    private fb: FormBuilder) { }

  searchForm = this.fb.group({
    from: [''],
    destination: [''],
    fromDate: [''],
    toDate: [''],
    numberOfPassengers: [1]
  })

  ngOnInit(): void {
    this.search();
  }

  search() {
    this.trainsService.searchTrains(this.searchForm.value as SearchTrains$Plain$Params)
      .subscribe(response => this.searchResult = response,
        this.handleError)
  }

  private handleError(err: any) {
    console.log("Response Error. Status: ", err.status);
    console.log("Response Error. Status Text: ", err.statusText);
    console.log(err)
  }


}


