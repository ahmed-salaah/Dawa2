using Exceptions;
using GHQ.Resources.Strings;
using Models;
using Service.Internet;
using Service.Network;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GHQ.Logic.Service.Lookup
{
    public class LookupService : ILookupService
    {
        #region Members

        INetworkService networkService;
        IInternetService internetService;
        #endregion

        public LookupService(INetworkService _networkService, IInternetService _internetService)
        {
            networkService = _networkService;
            internetService = _internetService;
        }

        public async Task<List<LookupData>> GetGenderAsync()
        {
            try
            {
                List<LookupData> gender = new List<LookupData>();
                LookupData male = new LookupData();
                male.ValueEn = "Male";
                male.ValueAr = "ذكر";
                gender.Add(male);
                LookupData female = new LookupData();
                female.ValueEn = "Female";
                female.ValueAr = "أنثي";
                gender.Add(female);
                return gender;
            }
            catch (InternetException ex)
            {
                throw ex;
            }
            catch (BackendException ex)
            {
                throw ex;
            }
            catch (ParsingException ex)
            {
                throw new ApplicationError(ex.Message, null, "LookupService.GetGender", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, null, "LookupService.GetGender", ex);
            }
        }

        public async Task<List<LookupData>> GetMealTypesAsync()
        {
            try
            {
                List<LookupData> GenderList = new List<LookupData>();
                LookupData meal = new LookupData();
				meal.Id = ((int)Enums.MealTime.Before).ToString();
                meal.ValueEn = AppResources.MedicineAddNew_MealType_Breakfast;
                meal.ValueAr = AppResources.MedicineAddNew_MealType_Breakfast;
                GenderList.Add(meal);
                meal = new LookupData();
				meal.Id = ((int)Enums.MealTime.Between).ToString();
                meal.ValueEn = AppResources.MedicineAddNew_MealType_Lunch;
                meal.ValueAr = AppResources.MedicineAddNew_MealType_Lunch;
                GenderList.Add(meal);
                meal = new LookupData();
				meal.Id = ((int)Enums.MealTime.After).ToString();
                meal.ValueEn = AppResources.MedicineAddNew_MealType_Dinner;
                meal.ValueAr = AppResources.MedicineAddNew_MealType_Dinner;
                GenderList.Add(meal);
                return GenderList;
            }
            catch (InternetException ex)
            {
                throw ex;
            }
            catch (BackendException ex)
            {
                throw ex;
            }
            catch (ParsingException ex)
            {
                throw new ApplicationError(ex.Message, null, "LookupService.GetMealTypesAsync", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, null, "LookupService.GetMealTypesAsync", ex);
            }
        }

        public async Task<List<LookupData>> GetMealTimeTypesAsync()
        {
            try
            {
                List<LookupData> mealTime = new List<LookupData>();
                LookupData meal = new LookupData();
				meal.Id = ((int)Enums.MealTime.After).ToString();
                meal.ValueEn = AppResources.MedicineAddNew_MealTypeTime_After;
                meal.ValueAr = AppResources.MedicineAddNew_MealTypeTime_After;
                mealTime.Add(meal);
                meal = new LookupData();
				meal.Id = ((int)Enums.MealTime.Before).ToString();
                meal.ValueEn = AppResources.MedicineAddNew_MealTypeTime_Before;
                meal.ValueAr = AppResources.MedicineAddNew_MealTypeTime_Before;
                mealTime.Add(meal);
                meal = new LookupData();
				meal.Id = ((int)Enums.MealTime.Between).ToString();
                meal.ValueEn = AppResources.MedicineAddNew_MealTypeTime_Between;
                meal.ValueAr = AppResources.MedicineAddNew_MealTypeTime_Between;
                mealTime.Add(meal);
                return mealTime;
            }
            catch (InternetException ex)
            {
                throw ex;
            }
            catch (BackendException ex)
            {
                throw ex;
            }
            catch (ParsingException ex)
            {
                throw new ApplicationError(ex.Message, null, "LookupService.GetMealTimeTypesAsync", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationError(ex.Message, null, "LookupService.GetMealTimeTypesAsync", ex);
            }
        }
    }
}
