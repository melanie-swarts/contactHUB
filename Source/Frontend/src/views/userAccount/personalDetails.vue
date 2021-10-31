<template>
<div>
    <v-tabs
      v-model="tab"
      background-color="#3C565B"
      dark
      fixed-tabs
    >
      <v-tab
        v-for="item in items"
        :key="item.tab"
      >
        {{ item.tab }}
      </v-tab>
    </v-tabs>

    <v-tabs-items v-model="tab">
      <v-tab-item class="tab-items">
        <v-card flat>
           <v-form ref="personal-details" class="info-form-box">
                <br>
                <el-row>
                  <el-form>
                    <v-select
                      v-model="user.systemUser.registrationTypeId"
                      :items="user.registrationTypes"                      
                      item-value="id"
                      ref="registrationType"
                      label="Registration Type"
                      :rules="personalDetailRules.RegistrationTypeId"
                      @change="selectedRegistrationType($event)"
                      item-text="registrationTypeName"
                      required
                      attach
                    />
                  </el-form>
                </el-row>
                <el-row id="business-details" v-if="businessApplicant" >
                  <el-col :span="11">
                    <v-text-field
                      v-model="user.systemUser.businessName"
                      :rules="fieldRules"
                      label="Business Name"
                      required
                    />
                  </el-col>
                  <el-col :span="1">
                    <br>
                  </el-col>
                  <el-col :span="12">
                    <v-text-field
                      v-model="user.systemUser.businessRegNumber"
                      label="Business Registration Number"
                    />
                  </el-col>
                </el-row>

                <el-row>
                  <el-col :span="11">
                    <v-text-field
                      v-model="user.systemUser.firstName"
                      label="First Name"
                      required
                    />
                  </el-col>
                  <el-col :span="1">
                    <br>
                  </el-col>
                  <el-col :span="12">
                    <v-text-field
                     v-model="user.systemUser.lastName"
                      label="Last Name"
                      required
                    />
                  </el-col>
                </el-row>

                <el-row>
                  <el-col :span="11">
                    <el-form>
                      <v-autocomplete
                        v-model="user.systemUser.countryId"
                        :items="user.countries"
                        :rules="personalDetailRules.CountryId"
                        item-value="id"
                        item-text="nicename"
                        label="Country"
                        required
                        attach
                      />
                    </el-form>
                  </el-col>
                  <el-col :span="1">
                    <br>
                  </el-col>
                  <el-col :span="12">
                    <el-form>
                      <v-select
                        v-model="user.systemUser.gender"
                        :items="gender"
                        :rules="personalDetailRules.Gender"
                        label="Gender"
                        required
                        attach
                      />
                    </el-form>
                  </el-col>
                </el-row>

                <el-row>
                  <el-col :span="11">
                    <el-form>
                      <v-select
                        v-model="user.systemUser.identificationType"
                        :items="identificationType"
                        :rules="personalDetailRules.IdentificationType"
                        label="Identification Type"
                        required
                        attach
                      />
                    </el-form>
                  </el-col>
                  <el-col :span="1">
                    <br>
                  </el-col>
                  <el-col :span="12">
                    <v-text-field
                      v-model="user.systemUser.identificationNo"
                      label="Identification Number"
                      required
                    />
                  </el-col>
                </el-row>
              </v-form>
        </v-card>
      </v-tab-item>
            <v-tab-item class="tab-items">
        <v-card flat>
             <v-form ref="form" class="info-form-box" lazy-validation>
                <br>
                <el-row>
                  <el-col :span="11">
                    <v-text-field
                      v-model="user.systemUser.telPrimary"
                      :rules="fieldRules"
                      label="Primary Contact Number"
                      number
                      required
                    />
                  </el-col>
                  <el-col :span="1">
                    <br>
                  </el-col>
                  <el-col :span="12">
                    <v-text-field
                    v-model="user.systemUser.telSecondary"
                      label="Secondary Contact Number"
                      number
                    />
                  </el-col>
                </el-row>

                <el-row>
                  <el-col :span="11">
                    <v-text-field
                    v-model="user.systemUser.telWork"
                      label="Work Number"
                      number
                    />
                  </el-col>
                  <el-col :span="1">
                    <br>
                  </el-col>
                  <el-col :span="12">
                    <v-text-field
                      v-model="user.systemUser.telFax"
                      label="Fax Number"
                      number
                    />
                  </el-col>
                </el-row>
              </v-form>
        </v-card>
      </v-tab-item>
      <v-tab-item class="tab-items">
        <v-card flat>
            <v-form ref="form" class="info-form-box" lazy-validation>
                <br>
                <el-row>
                  <el-col :span="11">
                    <div class="section-info-header">Physical Address</div>
                    <el-form>
                      <v-select
                      v-model="user.systemUser.physicalAddress.addressType"
                        :items="physicalAddressType"
                        :rules="fieldRules"
                        label="Select Address Type"
                        @change="selectedPhysicalAddressType($event)"
                        required
                        attach
                      />
                    </el-form>
                    <v-text-field
                    v-model="user.systemUser.physicalAddress.complexName"
                      v-if="isComplexPhysicalAddress" 
                      label="Unit Number and Complex Name"
                      required
                    />
                    <v-text-field
                    v-model="user.systemUser.physicalAddress.streetName"
                      label="Street Number and Name"
                      :rules="fieldRules"
                      required
                    />
                    <v-text-field
                    v-model="user.systemUser.physicalAddress.suburb"
                      label="Suburb"
                    />
                    <v-text-field
                    v-model="user.systemUser.physicalAddress.city"
                      label="City/Town"
                      :rules="fieldRules"
                      required
                    />
                    <v-text-field
                    v-model="user.systemUser.physicalAddress.postalCode"
                      label="Postal Code"
                      :rules="fieldRules"
                      required
                    />
                  </el-col>
                  <el-col :span="1">
                    <br>
                  </el-col>
                  <el-col :span="11">
                    <div class="section-info-header">Postal Address</div>
                    <el-form>
                      <v-select
                      v-model="user.systemUser.postalAddress.addressType"
                        :items="postalAddressType"
                        :rules="fieldRules"
                        label="Select Address Type"
                        @change="selectedPostalAddressType($event)"
                        required
                        attach
                      />
                    </el-form>
                    <v-text-field
                    v-model="user.systemUser.postalAddress.complexName"
                      v-if="isComplexPostalAddress"
                      label="Unit Number and Complex Name"
                      required
                    />
                    <v-text-field
                    v-model="user.systemUser.postalAddress.postbox"
                      v-if="isPostalAddress"
                      :rules="fieldRules"
                      label="Postbox Number"
                      required
                    />
                    <v-text-field
                    v-model="user.systemUser.postalAddress.streetName"
                      v-if="isResidentialPostalAddress"
                      :rules="fieldRules"
                      label="Street Number and Name"
                      required
                    />
                    <v-text-field
                    v-model="user.systemUser.postalAddress.suburb"
                      label="Suburb"
                    />
                    <v-text-field
                    v-model="user.systemUser.postalAddress.city"
                      label="City/Town"
                      :rules="fieldRules"
                      required
                    />
                    <v-text-field
                    v-model="user.systemUser.postalAddress.postalCode"
                      label="Postal Code"
                      :rules="fieldRules"
                      required
                    />
                  </el-col>
                </el-row>
              </v-form>
        </v-card>
      </v-tab-item>
    <v-tab-item class="tab-items">
        <v-card flat>
        <v-form ref="form" class="info-form-box" lazy-validation>
                <br>

                <strong>List Uploaded docs here</strong>

                <br>

                <vue-dropzone
                  id="dropzone"
                  ref="myVueDropzone"
                  :options="dropzoneOptions"
                  @vdropzone-file-added="fileAdded"
                  @vdropzone-removed-file="fileRemoved"
                />

                <br>
              </v-form>
        </v-card>
      </v-tab-item>
    </v-tabs-items>

<div>
       <div class="button-area">
            <v-btn x-large tile color="#D3D3D3" width="300px" dark>Cancel</v-btn>
            <v-btn x-large tile  color="#3C565B" width="300px" dark class="submit-button">Update</v-btn>
          </div>
</div>
 
</div>
</template>

<script>
import { mapGetters } from 'vuex'
import store from '@/store/store'
import { mapState } from 'vuex'
import vue2Dropzone from 'vue2-dropzone'
import 'vue2-dropzone/dist/vue2Dropzone.min.css'
import moment from 'moment'

  export default {
    components: {
        vueDropzone: vue2Dropzone
    },
    data () {
      return {
        tab: null,
        items: [
          { tab: 'Personal Details' },
          { tab: 'Contact Information' },
          { tab: 'Address Information'},
          { tab: 'Documentation' }
        ],
        //systemUser: user.systemUser,
        businessApplicant: false,
        isComplexPhysicalAddress: false,
        isResidentialPostalAddress: false,
        isComplexPostalAddress: false,
        isComplexPostalAddress: false,
        isPostalAddress: true,
        gender: ['Male', 'Female'],
        identificationType: [name='RSA ID', 'RSA Passport', 'Foreign ID', 'Foreign Passport'],
        physicalAddressType: ['Complex', 'Residential'],
        postalAddressType: ['Complex', 'Residential', 'Postal'],
        fieldRules: [
            v => !!v || 'Field is required'
        ],
        dropzoneOptions: {
        url: 'https://httpbin.org/post',
        paramName: "file",
        thumbnailWidth: 120,
        maxFilesize: 4, //MB
        headers: { 'My-Awesome-Header': 'header value' },
        addRemoveLinks: true,
        myAwesomeDropzone: true
      },
        personalDetailRules: {
            RegistrationTypeId: [
            val => val < 10 || 'Registration type is required.',
            ],
            FirstName: [val => (val || '').length > 0 || 'FirstName is required.'],
            LastName: [val => (val || '').length > 0 || 'LastName is required'],
            CountryId: [
            val => val < 239 || 'Country is required.',
            ],
            Gender: [val => (val || '').length > 0 || 'Gender is required.'],
            IdentificationType: [val => (val || '').length > 0 || 'Identification type is required.'],
            IdentificationNo: [val => (val || '').length > 0 || 'Identification number is required.']
        }
      }
    },
      computed: {
    ...mapState(['systems', 'user', 'applications'])
  },
    created() {
    this.getCountries()
    this.getRegistrationTypes()
    
    if (store.getters.systemUser.length === 0) {
      this.getSystemUser()
    }
  },
    methods: {
    getSystemUser() {
      return this.$store.dispatch('fetchSystemUser')
    },
    selectedRegistrationType(event){
        if (event === 1){
            this.businessApplicant = true
        }
        else{
            this.businessApplicant = false
        }
        },
        selectedPhysicalAddressType(event){
        if (event === 'Complex'){
            this.isComplexPhysicalAddress = true
        }
        else{
            this.isComplexPhysicalAddress = false
        }
        },
        selectedPostalAddressType(event){
        if (event === 'Complex'){
            this.isComplexPostalAddress = true
            this.isResidentialPostalAddress = true
            this.isPostalAddress = false
        }
        else if (event === 'Residential'){
            this.isComplexPostalAddress = false
            this.isResidentialPostalAddress = true
            this.isPostalAddress = false
        }
        else{
            this.isComplexPostalAddress = false
            this.isResidentialPostalAddress = false
            this.isPostalAddress = true
        }
        },
        getCountries(){
        this.$store.dispatch('fetchCountries')
        },
        getRegistrationTypes(){
        this.$store.dispatch('fetchRegistrationTypes')
        },
            createFileUploadObject() {
      return {
        UploadDate: moment(Date()).format(),
        FileName: '',
        Description: '',
        ContentMimeType: '',
        Content: []
      }
    },
    fileAdded(file) {
      var uploadedFile = this.createFileUploadObject()
      uploadedFile.FileName = file.name
      uploadedFile.ContentMimeType = file.type

      return (this.getArrayBuffer(file).then(response => {
        uploadedFile.Content = btoa([].reduce.call(new Uint8Array(response), function(p, c) { return p + String.fromCharCode(c) }, ''))
        this.systemUser.SystemUserUploads.push(uploadedFile)
      }))
    },
    fileRemoved(file) {
      var array = this.systemUser.SystemUserUploads
      for (var i = array.length - 1; i >= 0; i--) {
        if (array[i].FileName === file.name) {
          array.splice(i, 1)
        }
      }
    }
    }
  }
</script>

<style rel="stylesheet/scss" lang="scss">
.tab-items {
    padding-left: 40px;
    padding-right: 40px;
}

.section-info-header {
  display: block;
  font-size: 16px;
  line-height: 1;
  font-weight: 500;
  text-transform: uppercase;
  color: darkgrey;
  text-align: center;
  padding-top: 5px;
  padding-bottom: 25px;
}

.submit-button{
    margin-left: 10px;
}

.button-area{
    display: flex; 
    justify-content: center;
    margin-top: 40px;
    padding-bottom: 50px;
}
</style>

