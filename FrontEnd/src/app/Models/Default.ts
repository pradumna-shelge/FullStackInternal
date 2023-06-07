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
            photoURL:string;
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


export interface payments{
    month: number;
    year : number;
    amount : number
}
export interface OTP{
    otp:string
}


export interface devoties{
    name : string,
                            id : string,
                            email : string,
                            lastAmount : string,
                            lastDate : string}