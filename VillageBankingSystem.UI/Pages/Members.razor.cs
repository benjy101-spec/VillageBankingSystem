using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.Generic;
using VillageBankingSystem.Shared.Models;
using VillageBankingSystem.UI.Services.Interfaces;

namespace VillageBankingSystem.UI.Pages
{
    public partial class Members : ComponentBase
    {
        private List<Member> _members = new List<Member>();
        private Member? _editingMember = null;

        [Inject]
        public IMemberService? MemberService { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; } = default!;

        protected override void OnInitialized()
        {
            LoadMembers();
        }

        private void LoadMembers()
        {
            if (MemberService != null)
            {
                _members = MemberService.GetMembers();
            }
        }

        private void AddNewMember()
        {
            var newMember = new Member { Name = "", Email = "", Phone = "" };
            _members.Insert(0, newMember);
            _editingMember = newMember;
        }

        private void EditMember(Member member)
        {
            _editingMember = new Member
            {
                Name = member.Name,
                Email = member.Email,
                Phone = member.Phone
            };
        }

        private void SaveMember(Member member)
        {
            if (string.IsNullOrWhiteSpace(_editingMember?.Name) || string.IsNullOrWhiteSpace(_editingMember?.Email))
            {
                Snackbar.Add("Name and Email are required.", Severity.Error);
                return;
            }

            if (MemberService != null && _editingMember != null)
            {
                try
                {
                    MemberService.AddOrUpdateMember(_editingMember);
                    LoadMembers();
                    Snackbar.Add("Member saved successfully.", Severity.Success);
                    _editingMember = null;
                }
                catch (System.Exception ex)
                {
                    Snackbar.Add($"Error saving member: {ex.Message}", Severity.Error);
                }
            }
        }

        private void CancelEdit()
        {
            if (_editingMember != null && string.IsNullOrEmpty(_editingMember.Name) && string.IsNullOrEmpty(_editingMember.Email))
            {
                _members.Remove(_editingMember);
            }
            _editingMember = null;
        }

        private void DeleteMember(Member member)
        {
            if (MemberService != null)
            {
                try
                {
                    MemberService.DeleteMember(member);
                    LoadMembers();
                    Snackbar.Add("Member deleted successfully.", Severity.Success);
                }
                catch (System.Exception ex)
                {
                    Snackbar.Add($"Error deleting member: {ex.Message}", Severity.Error);
                }
            }
        }
    }
}
