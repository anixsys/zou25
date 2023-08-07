<template>
    <v-row justify="center" align="center" class="mt-5">
      <v-col md="8">
        <v-card>
            <v-card-text>
                <v-row>
            <v-col md="12" sm="12" xs="12">
                <div class="text-h4 mb-5">Create Account</div>
        <v-form
      ref="form"
      v-model="valid"
      lazy-validation
    >
     <v-row>
        <v-col>
            <v-text-field
            dense
              label="Name"
              v-model="form.name"
              outlined
              :rules="[rules.required]"
            ></v-text-field> 
        </v-col>
        <v-col>
            <v-text-field
            dense
              label="Surname"
              v-model="form.surname"
              outlined
              :rules="[rules.required]"
            ></v-text-field> 
        </v-col>
     </v-row>
         <v-row>
            <v-col>
                <v-select
                dense
              label="Title"
              v-model="form.title"
              :items="['Mr','Mrs','Miss','Ms']"
              outlined
              :rules="[rules.required]"
            ></v-select>
            </v-col>
            <v-col>
                <v-select
                 dense
              label="Marital Status"
              v-model="form.maritalStatus"
              :items="['single','married','window','divorced']"
              outlined
              :rules="[rules.required]"
            ></v-select>
            </v-col>
         </v-row>
         <v-row>
        <v-col>
            <v-text-field
            dense
              label="Maiden Name"
              v-model="form.maidenName"
              outlined
            ></v-text-field> 
        </v-col>
        <v-col>
            <v-menu
      ref="menu"
      v-model="menu"
      :close-on-content-click="false"
      transition="scale-transition"
      offset-y
      min-width="auto"
    >
      <template v-slot:activator="{ on, attrs }">
        <v-text-field
          v-model="date"
          dense
          label="Date of Birth"
          prepend-icon="mdi-calendar"
          outlined
          readonly
          :rules="[rules.required]"
          v-bind="attrs"
          v-on="on"
        ></v-text-field>
      </template>
      <v-date-picker
        v-model="date"
        :active-picker.sync="activePicker"
        :max="(new Date(Date.now() - (new Date()).getTimezoneOffset() * 60000)).toISOString().substr(0, 10)"
        min="1950-01-01"
        @change="save"
      ></v-date-picker>
    </v-menu>
        </v-col>
     </v-row>
     <v-row>
        <v-col>
            <v-select
            dense
              label="Identification Type"
              v-model="form.identificationType" 
              outlined
              :items="['National ID','Passport Number']"          
              :rules="[rules.required]"
            ></v-select> 
        </v-col>
        <v-col>
            <v-text-field
            dense
            outlined
              label="Identification Number"
              v-model="form.identification"             
            ></v-text-field> 
        </v-col>
    </v-row>
    <v-row>
            <v-col>
                <v-select
                dense
              label="Gender"
              v-model="form.gender"
              :items="['F','M']"
              outlined
              :rules="[rules.required]"
            ></v-select>
            </v-col>
            <v-col>
            <v-text-field
            dense
              label="Address"
              v-model="form.address"
              outlined
              :rules="[rules.required]"
            ></v-text-field> 
        </v-col>
    </v-row>
    <v-row>
            <v-col>
                <v-select
                dense
              label="Country"
              v-model="form.country"
              :items="countrylist"
              outlined
              :rules="[rules.required]"
            ></v-select>
            </v-col>
            <v-col>
            <v-text-field
            dense
              label="City"
              v-model="form.city"
              outlined
              :rules="[rules.required]"
            ></v-text-field> 
        </v-col>
    </v-row>
      <v-row>
        <v-col>
            <v-text-field
            dense
              label="Email"
              v-model="form.email"
              outlined
              :rules="[rules.required]"
            ></v-text-field> 
        </v-col>
        <v-col>
            <v-text-field
            dense
              label="Mobile Number"
              v-model="form.phonenumber"
              outlined
              :rules="[rules.required]"
            ></v-text-field> 
        </v-col>
      </v-row>

    <v-row>
        <v-col>
            <v-text-field
            dense
              label="Password"
              placeholder="Password"
              v-model="form.password"
              :type="show1 ? 'text' : 'password'"
              outlined
              :rules="[rules.required, rules.min]"
              class="mt-3"
              :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'"
              @click:append="show1 = !show1"
            ></v-text-field>   
        </v-col>
        <v-col>
            <v-text-field
            dense
              label="Confirm Password"
              v-model="form.password_confirmation"
              :type="show1 ? 'text' : 'password'"
              outlined
              :rules="confirmpasswordRule"
              class="mt-3"
              :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'"
              @click:append="show1 = !show1"
            ></v-text-field>   
        </v-col>
    </v-row>

                    
   
      </v-form>
  
      </v-col>
        </v-row>
       
            </v-card-text>
            <v-card-actions>
                <v-btn  color="error" to="/" depressed  :loading="loading">Cancel</v-btn>
                <v-spacer/>
                <v-btn  color="primary" depressed @click="Login()" :loading="loading">Submit</v-btn>
            </v-card-actions>
        </v-card>
        
       
        <v-btn text block to="/login" class="mt-2">Already have an account?</v-btn>
      </v-col>
      
    </v-row>
  </template>
  
  <script>
  export default {
    name: 'Login',
    auth: 'guest',
    data(){
      return{
        activePicker: null,
      date: null,
      menu: false,
        valid:false,
        show1:false,
        loading:false,
        form:{
          title:"",
          name:"",
          surname:"",
          maritalStatus:"",
          maidenName:"",
          dob:"",
          identificationType:"",
          identification:"",
          gender:"",
          address:"",
          city:"",
          country:"",
          phonenumber:"",
          email:"",
          password:"",
          password_confirmation:""
        },
        rules: {
            required: value => !!value || 'Required.',
            min: v => v.length >= 8 || 'Min 8 characters',
            emailMatch: () => (`The email and password you entered don't match`),
          },
          confirmpasswordRule: [
        (v) => !!v || "Password is required",
        (v) =>
          (v && v.length == this.form.password.length) ||
          "Passwords must match",
      ],
          countrylist: [
        "Zimbabwe",
        "Afghanistan",
        "Albania",
        "Algeria",
        "American Samoa",
        "Andorra",
        "Angola",
        "Anguilla",
        "Antarctica",
        "Antigua and Barbuda",
        "Argentina",
        "Armenia",
        "Aruba",
        "Australia",
        "Austria",
        "Azerbaijan",
        "Bahamas",
        "Bahrain",
        "Bangladesh",
        "Barbados",
        "Belarus",
        "Belgium",
        "Belize",
        "Benin",
        "Bermuda",
        "Bhutan",
        " Bolivia",
        "Bosnia and Herzegovina",
        "Botswana",
        "Bouvet Island",
        "Brazil",
        "British Indian Ocean Territory",
        "Brunei Darussalam",
        "Bulgaria",
        "Burkina Faso",
        "Burundi",
        "Cambodia",
        "Cameroon",
        "Canada",
        "Cape Verde",
        "Cayman Islands",
        "Central African Republic",
        "Chad",
        "Chile",
        "China",
        "Christmas Island",
        "Cocos (Keeling Islands)",
        "Colombia",
        "Comoros",
        "Congo",
        " Cook Islands",
        " Costa Rica",
        " Cote D Ivoire (Ivory Coast)",
        " Croatia (Hrvatska",
        " Cuba",
        " Cyprus",
        " Czech Republic",
        " Denmark",
        " Djibouti",
        " Dominica",
        " Dominican Republic",
        " East Timor",
        " Ecuador",
        " Egypt",
        " El Salvador",
        " Equatorial Guinea",
        " Eritrea",
        " Estonia",
        " Ethiopia",
        " Falkland Islands (Malvinas)",
        " Faroe Islands",
        " Fiji",
        " Finland",
        " France",
        " France",
        " Metropolitan",
        " French Guiana",
        " French Polynesia",
        " French Southern Territories",
        " Gabon",
        " Gambia",
        " Georgia",
        " Germany",
        " Ghana",
        " Gibraltar",
        " Greece",
        " Greenland",
        " Grenada",
        " Guadeloupe",
        " Guam",
        " Guatemala",
        " Guinea",
        " Guinea-Bissau",
        " Guyana",
        " Haiti",
        " Heard and McDonald Islands",
        " Honduras",
        " Hong Kong",
        " Hungary",
        " Iceland",
        " India",
        " Indonesia",
        " Iran",
        " Iraq",
        " Ireland",
        " Israel",
        " Italy",
        " Jamaica",
        " Japan",
        " Jordan",
        " Kazakhstan",
        " Kenya",
        " Kiribati",
        " Korea (North)",
        " Korea (South)",
        " Kuwait",
        " Kyrgyzstan",
        " Laos",
        " Latvia",
        " Lebanon",
        " Lesotho",
        " Liberia",
        " Libya",
        " Liechtenstein",
        " Lithuania",
        " Luxembourg",
        " Macau",
        " Macedonia",
        " Madagascar",
        " Malawi",
        " Malaysia",
        " Maldives",
        " Mali",
        " Malta",
        " Marshall Islands",
        " Martinique",
        " Mauritania",
        " Mauritius",
        " Mayotte",
        " Mexico",
        " Micronesia",
        " Moldova",
        " Monaco",
        " Mongolia",
        " Montserrat",
        " Morocco",
        " Mozambique",
        " Myanmar",
        " Namibia",
        " Nauru",
        " Nepal",
        " Netherlands",
        " Netherlands Antilles",
        " New Caledonia",
        " New Zealand",
        " Nicaragua",
        " Niger",
        " Nigeria",
        " Niue",
        " Norfolk Island",
        " Northern Mariana Islands",
        " Norway",
        " Oman",
        " Pakistan",
        " Palau",
        " Panama",
        " Papua New Guinea",
        " Paraguay",
        " Peru",
        " Philippines",
        " Pitcairn",
        " Poland",
        " Portugal",
        " Puerto Rico",
        " Qatar",
        " Reunion",
        " Romania",
        " Russian Federation",
        " Rwanda",
        " Saint Kitts and Nevis",
        " Saint Lucia",
        " Saint Vincent and The Grenadines",
        "Samoa",
        "San Marino",
        "Sao Tome and Principe",
        "Saudi Arabia",
        "Senegal",
        "Seychelles",
        "Sierra Leone",
        " Singapore",
        " Slovak Republic",
        " Slovenia",
        " Solomon Islands",
        " Somalia",
        " South Africa",
        " S. Georgia and S. Sandwich Isls.",
        " Spain",
        " Sri Lanka",
        " St. Helena",
        "St. Pierre and Miquelon",
        "Sudan",
        "Suriname",
        "Svalbard and Jan Mayen Islands",
        " Swaziland",
        " Sweden",
        " Switzerland",
        " Syria",
        " Taiwan",
        " Tajikistan",
        " Tanzania",
        " Thailand",
        " Togo",
        " Tokelau",
        " Tonga",
        " Trinidad and Tobago",
        " Tunisia",
        " Turkey",
        " Turkmenistan",
        " Turks and Caicos Islands",
        " Tuvalu",
        " Uganda",
        " Ukraine",
        " United Arab Emirates",
        " United Kingdom (Britain / UK)",
        " United States of America (USA)",
        " US Minor Outlying Islands",
        " Uruguay",
        " Uzbekistan",
        " Vanuatu",
        " Vatican City State (Holy See)",
        " Venezuela",
        " Viet Nam",
        " Virgin Islands (British)",
        "Virgin Islands (US)",
        "Wallis and Futuna Islands",
        "Western Sahara",
        "Yemen",
        "Yugoslavia",
        "Zaire",
        " Zambia",
      ],
      }
    }, watch: {
      menu (val) {
        val && setTimeout(() => (this.activePicker = 'YEAR'))
      },
    },methods:{
        save (date) {
        this.$refs.menu.save(date)
      },
      async Login(){
        if (this.$refs.form.validate()) {
        this.valid = true;
        this.overlay = true;
        this.form.dob = this.date
        try {
          this.$axios
            .post("Auth/register", this.form)
            .then((res) => {
                if(res.data.status)
                {
                this.$swal("success", res.data.message, "success");
                this.$router.push("login");
                }else{
                    this.$swal("error", res.data.message, "error");  
                }
             
            })
            .catch((err) => {
              this.overlay = false;
              this.$swal("error", err.response.data.message, "error");
            });
        } catch (err) {
          this.overlay = false;
          this.$swal("error", err.response.data.message, "error");
        }
      }
      }
    }
    
  }
  </script>
  