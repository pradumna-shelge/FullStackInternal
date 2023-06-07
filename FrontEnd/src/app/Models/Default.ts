export interface signData{
token:string,
role:string
}

export interface city{
    id:number,
    name:string
    }

    export interface Image{
        url:string
        }


        export interface UserData {
            userId: string;
            firstName: string;
            lastName: string;
            email: string;
            middleName: string;
            flatNumber: string;
            stateId: number;
            cityId: number;
            pinCode: string;
            addressLine: string;
            initiationDate: Date;
          }